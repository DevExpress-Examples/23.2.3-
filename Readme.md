<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128597700/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T335238)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/DifferentBrickTypes/Form1.cs) (VB: [Form1.vb](./VB/DifferentBrickTypes/Form1.vb))
<!-- default file list end -->
# How to: Use Bricks of Different Types


<p>The following example demonstrates how to use bricks of different types to display different kinds of information in a report.</p>
<p>First, drop a simple button onto a form and handle its <strong>Click</strong> event. In the event handler, create a new <strong>PrintingSystem</strong> class instance. Then, create a new <strong>Link</strong> object and add it to the printing system's <strong>Links</strong> collection. Subscribe to the link's <strong>CreateDetailArea</strong> and <strong>CreateMarginalHeaderArea</strong> events to customize a document's detail and marginal header sections, respectively. Finally, create a document and show it in the print preview by calling the <strong>ShowPreview</strong> method.</p>
<p>In the <strong>CreateDetailArea</strong> event handler, use the <strong>ImageBrick</strong> object to display the picture of a fish and the <strong>TextBrick</strong> object to show text containing species characteristics and its description. The code also adds a <strong>CheckBoxBrick</strong> to the document and uses a simple <strong>Brick</strong> to draw borders around specific bricks.</p>
<p>The <strong>CreateMarginalHeaderArea</strong> event handler uses the <strong>PageImageBrick</strong> and <strong>PageInfoBrick</strong> objects to show additional information in the page header. The <strong>PageImageBrick</strong> displays the DevExpress logo at the top of every page, while two <strong>PageInfo</strong> bricks display either the current date and time or the page number, depending on the <strong>PageInfo</strong> property value.</p>

<br/>


