<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128597700/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T335238)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# How to: Use Bricks of Different Types

The following example demonstrates how to use bricks of different types to display different kinds of information in a report.

## Implementation Details

First, drop a simple button onto a form and handle its `Click` event. In the event handler, create a new `PrintingSystem` class instance. Then, create a new `Link` object and add it to the printing system's `Links` collection. Subscribe to the link's `CreateDetailArea` and `CreateMarginalHeaderArea` events to customize a document's detail and marginal header sections, respectively. Finally, create a document and show it in the print preview by calling the `ShowPreview` method.

In the `CreateDetailArea` event handler, use the `ImageBrick` object to display the picture of a fish and the `TextBrick` object to show text containing species characteristics and descriptions. The code also adds a `CheckBoxBrick` to the document and uses a simple `Brick` to draw borders around specific bricks.

The `CreateMarginalHeaderArea` event handler uses the `PageImageBrick` and `PageInfoBrick` objects to show additional information in the page header. The `PageImageBrick` displays the DevExpress logo at the top of every page, while two `PageInfo` bricks display either the current date and time or the page number, depending on the `PageInfo` property value.

## Files to Review

* [Form1.cs](./CS/DifferentBrickTypes/Form1.cs) (VB: [Form1.vb](./VB/DifferentBrickTypes/Form1.vb))


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-printing-library-use-different-brick-types&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-printing-library-use-different-brick-types&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
