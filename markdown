
### Using Markdown in Articles

Markdown is designed as an easy language for writing, so its syntax is quite simplified. It uses punctuation characters only, and uses them in ways they are often already used. For example, to emphasize some text, you would type `*emphasized text*`. That is delivered to the web browser as `<em>emphasized text</em>`, and rendered on screen as *emphasized text*.

#### Paragraphs

To create a new paragraph in Markdown, create a blank line between two written paragraphs - it can contain any whitespace characters (space, tab, etc), as long as it appears blank.

```html
This is the first paragraph.

This is the second paragraph
.
<p>This is the first paragraph.</p>

<p>This is the second paragraph</p>
```
::::::output
:::::outputContainer
::::
:::pullout

Output

:::
:::
This is the first paragraph.

This is the second paragraph
:::
::::
:::::
::::::

Markdown will treat a single new line as part of the same paragraph, and ignores the newline. To keep a line break, you need to enter two spaces before pressing `Enter`:

```html
This is a sentence with one space after it.→
This is the second sentence of the paragraph.
.
<p>This is the first paragraph. This is the second sentence of the paragraph.</p>

This is the a sentence with two spaces after it.→→
This is the second sentence of the paragraph.
.
<p>This is the first paragraph.<br />
This is the second sentence of the paragraph.</p>
```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
This is a sentence with one space after it. 
This is the second sentence of the paragraph.  
.  
This is the a sentence with two spaces after it.  
This is the second sentence of the paragraph.
:::
::::
:::::
::::::

#### Headers

To set a header, place a number of `#` equal to the intended header level before the header text. There must be a space between the `#` and the header text, and the header may be the only thing on the line. Optionally, you may close the header with `#` as well, with any number of `#`.

```html
##### Headers
### Headers #
.
<h5>Headers</h5>
<h3>Headers</h3>
```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
##### Headers
### Headers #
:::
::::
:::::
::::::

#### Emphasis [](#emphasis)

```html
*emphasis/italics*
**strong/bold**  
~~strikethrough/deleted~~
sub~script~
super^script^
++inserted text++
==marked text==


<em>emphasis/italics</em>
<strong>strong/bold</strong>
<del>strikethrough/deleted</del>
sub<sub>script</sub>
super<sup>script</sup>
<ins>inserted text</ins>
<mark>marked text</mark>
```

#### Lists

Markdown supports both ordered (numbered) and unordered lists.

For ordered lists, start a new line with a number followed by a `.` and a space, then your list item. Each list item will go on a new line. 

```html
1. List item
2. List item
3. List item
.
<ol>
    <li>List item</li>
    <li>List item</li>
    <li>List item</li>
</ol>
````

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
1. List item
2. List item
3. List item
:::
::::
:::::
::::::

Only the first number matters, as it sets which number your list starts with; the other list items can use any numbers.

```html
3. Item 1
1. Item 2
9. Item 3
.
<ol start="3">
    <li>Item 1</li>
    <li>Item 2</li>
    <li>Item 3</li>
</ol>
```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
3. Item 1
1. Item 2
9. Item 3
:::
::::
:::::
::::::

Unordered lists can use `*`, `-`, or `+` as the designator, followed by a space, and then the list item.

```html
* Item 1
* Item 2
* Item 3
```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
* Item 1
* Item 2
* Item 3
:::
::::
:::::
::::::

#### Links

To create an inline link, wrap the desired text in `[ ]`, and place the URL in `( )`.

```html
[Lafayette Consolidated Government](https://www.lafayettela.gov)
.
<a href="https://www.lafayettela.gov">Lafayette Consolidated Government</a>
```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
[Lafayette Consolidated Government](https://www.lafayettela.gov)  
:::
::::
:::::
::::::

#### Code

To highlight small segments of code inline, surround your code with the backtick character `` ` ``. You've seen several examples of what that looks like throughout this article.

```html
You cannot implicitly convert variable type `string` to `int`.
.
You cannot implicitly convert variable type <code>string</code> to <code>int</code>.
```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
You cannot implicitly convert variable type `string` to `int`.
:::
::::
:::::
::::::

For larger pieces of code, you can use a code block, which will even allow syntax highlighting. On a new line, enter three (or more) backticks, and then optionally the name of the language you will be using to enable syntax highlighting. Type your code, including indents, and then on a new line type the same number of backticks you used to open the block.

Supported languages include C# (csharp), HTML, JavaScript (js), CSS, and more.

````
```html
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Title)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.CreatedBy)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.CreatedDate)
            </th>
            <!-- <th></th> -->
        </tr>
    </thead>
```
````

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
```html
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Title)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.CreatedBy)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.CreatedDate)
            </th>
            <!-- <th></th> -->
        </tr>
    </thead>
```
:::
::::
:::::
::::::

````
```csharp
// GET: Topics
public async Task<IActionResult> Index()
{
    return View(await _context.Topic.ToListAsync());
}
```
````

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::
```csharp
// GET: Topics
public async Task<IActionResult> Index()
{
    return View(await _context.Topic.ToListAsync());
}
```
:::
::::
:::::
::::::


<!-- blank templates for future additions
```html

```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::

:::
::::
:::::
::::::



```html

```

::::::output
:::::outputContainer
::::
:::pullout
Output
:::
:::

:::
::::
:::::
:::::: -->
