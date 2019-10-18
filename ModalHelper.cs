using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace HTMLExtensions
{
    /// <summary>
    /// Class that actually allows for creation of block elements with HTML inside it.
    /// Implements <c>IDisposable</c> to take care of start and end blocks of code.
    /// </summary>
    public class DisposableTag : IDisposable
    {
        private Action End;

        public DisposableTag(Action start, Action end)
        {
            End = end;
            start();
        }

        public void Dispose()
        {
            End();
        }
    }

    /// <summary>
    /// HTMLHelper utilities for creating Bootstrap modals.
    /// </summary>
    public static class HTMLHelpers
    {
        /// <summary>
        /// Method for creating a modal which will have a footer with buttons or additional text.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id">The HTML <c>id</c> attribute used to target the hide/show functionality of the modal</param>
        /// <param name="titleText">The text to use in the title <c>h4</c>  tag of the modal</param>
        /// <param name="htmlAttributes">An optional object representing HTML attributes to apply to the modal itself</param>
        /// <param name="titleHtmlAttributes">An optional object representing HTML attributes to apply to the title</param>
        /// <returns><c>DisposableTag</c> responsible for creating the opening and closing blocks of code</returns>
        public static DisposableTag ModalBody(this HtmlHelper html, string id, string titleText, object htmlAttributes = null, object titleHtmlAttributes = null)
        {
            return new DisposableTag
            (
                () => html.BeginModal(id, titleText, htmlAttributes, titleHtmlAttributes),
                () => html.EndModalBody()
            );
        }

        /// <summary>
        /// Method for creating a modal footer which will contain buttons or additional text, separate from the body.
        /// </summary>
        /// <param name="html"></param>
        /// <returns><c>DisposableTag</c> responsible for creating the opening and closing blocks of code</returns>
        public static DisposableTag ModalFooter(this HtmlHelper html)
        {
            return new DisposableTag
            (
                () => html.BeginModalFooter(),
                () => html.EndModal()
            );
        }

        /// <summary>
        /// Method for creating a modal with only a body and no footer. Useful for alerts, information, requiring no interaction.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id">The HTML <c>id</c> attribute used to target the hide/show functionality of the modal</param>
        /// <param name="titleText">The text to use in the title <c>h4</c>  tag of the modal</param>
        /// <param name="htmlAttributes">An optional object representing HTML attributes to apply to the modal itself</param>
        /// <param name="titleHtmlAttributes">An optional object representing HTML attributes to apply to the title</param>
        /// <returns><c>DisposableTag</c> responsible for creating the opening and closing blocks of code</returns>
        public static DisposableTag ModalNoFooter(this HtmlHelper html, string id, string titleText, object htmlAttributes = null, object titleHtmlAttributes = null)
        {
            return new DisposableTag
            (
                () => html.BeginModal(id, titleText, htmlAttributes, titleHtmlAttributes),
                () => html.EndModal()
            );
        }

        /// <summary>
        /// Method that creates the opening block of code for the modal. This can be called directly, but then will also have to manually be closed with <c>EndModalBody</c>
        /// </summary>
        /// <param name="html"></param>
        /// <param name="id">The HTML <c>id</c> attribute used to target the hide/show functionality of the modal</param>
        /// <param name="titleText">The text to use in the title <c>h4</c>  tag of the modal</param>
        /// <param name="htmlAttributes">An optional object representing HTML attributes to apply to the modal itself</param>
        /// <param name="titleHtmlAttributes">An optional object representing HTML attributes to apply to the title</param>
        public static void BeginModal(this HtmlHelper html, string id, string titleText, object htmlAttributes, object titleHtmlAttributes)
        {
            var raw = new StringBuilder();
            var outer = new TagBuilder("div");
            var dialog = new TagBuilder("div");
            var content = new TagBuilder("div");
            var header = new TagBuilder("div");
            var title = new TagBuilder("h4");
            var body = new TagBuilder("div");

            outer.AddCssClass("modal fade");
            outer.MergeAttributes(new Dictionary<string, string>(){ { "tabindex", "-1"}, { "role", "dialog"}, { "id", id} });
            raw.Append(outer.ToString(TagRenderMode.StartTag));

            dialog.MergeAttributes(new Dictionary<string, string>() { { "class", "modal-dialog" }, { "role", "document" } });
            dialog.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            raw.Append(dialog.ToString(TagRenderMode.StartTag));

            content.AddCssClass("modal-content");
            raw.Append(content.ToString(TagRenderMode.StartTag));

            var button = new TagBuilder("button");
            var span = new TagBuilder("span");
            button.MergeAttributes(new Dictionary<string, string>() { { "type", "button" }, { "class", "close" }, { "data-dismiss", "modal" } });
            span.InnerHtml = "&times;";
            button.InnerHtml = span.ToString(TagRenderMode.Normal);

            header.AddCssClass("modal-header");
            header.InnerHtml = button.ToString(TagRenderMode.Normal);
            title.AddCssClass("modal-title");
            title.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(titleHtmlAttributes));
            title.InnerHtml = titleText;
            header.InnerHtml += title.ToString(TagRenderMode.Normal);
            raw.Append(header.ToString(TagRenderMode.Normal));

            body.AddCssClass("modal-body");
            raw.Append(body.ToString(TagRenderMode.StartTag));

            var modal = MvcHtmlString.Create(raw.ToString());
            html.ViewContext.Writer.Write(modal);

        }

        /// <summary>
        /// Creates the closing tags of the modal body
        /// </summary>
        /// <param name="html"></param>
        public static void EndModalBody(this HtmlHelper html)
        {
            html.ViewContext.Writer.Write("</div>");
        }

        /// <summary>
        /// Creates the starting tag of the modal footer.
        /// </summary>
        /// <param name="html"></param>
        public static void BeginModalFooter(this HtmlHelper html)
        {
            var footer = new TagBuilder("div");
            footer.AddCssClass("modal-footer");
            html.ViewContext.Writer.Write(footer.ToString(TagRenderMode.StartTag));
        }

        /// <summary>
        /// Creates the closing tags for the modal. This is called in either the with-footer or without-footer methods.
        /// </summary>
        /// <param name="html"></param>
        public static void EndModal(this HtmlHelper html)
        {
            html.ViewContext.Writer.Write("</div></div></div></div>");
        }
    }
}
