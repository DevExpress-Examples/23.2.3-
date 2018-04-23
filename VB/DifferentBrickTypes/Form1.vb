Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting

Namespace DifferentBrickTypes
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            ' Create a new Printing System.
            Dim printingSystem As New PrintingSystem()

            ' Create a link and add it to the printing system's collection of links.
            Dim link As New Link()
            printingSystem.Links.Add(link)

            ' Subscribe to the events to customize the detail and marginal page header sections of a document.
            AddHandler link.CreateDetailArea, AddressOf Link_CreateDetailArea
            AddHandler link.CreateMarginalHeaderArea, AddressOf Link_CreateMarginalHeaderArea

            ' Create a document and show it in the document preview.
            link.ShowPreview()
        End Sub

        Private Sub Link_CreateDetailArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
            ' Specify required settings for the brick graphics.
            Dim brickGraphics As BrickGraphics = e.Graph
            Dim format As New BrickStringFormat(StringAlignment.Near, StringAlignment.Center)
            brickGraphics.StringFormat = format
            brickGraphics.BorderColor = SystemColors.ControlDark

            ' Declare bricks.
            Dim imageBrick As ImageBrick
            Dim textBrick As TextBrick
            Dim checkBrick As CheckBoxBrick
            Dim brick As Brick

            ' Declare text strings.
            Dim rows() As String = { "Species No:", "Length (cm):", "Category:", "Common Name:", "Species Name:" }, desc() As String = { "90070", "30", "Angelfish", "Blue Angelfish", "Pomacanthus nauarchus" }

            Dim note As String = "Habitat is around boulders, caves, coral ledges and crevices in shallow waters. " & "Swims alone or in groups. Its color changes dramatically from juvenile to adult. The mature" & " adult fish can startle divers by producing a powerful drumming or thumping sound intended " & "to warn off predators. Edibility is good. Range is the entire Indo-Pacific region."

            ' Define the image to display.
            Dim img As Image = Image.FromFile("..\..\angelfish.png")

            ' Start creation of a non-separable group of bricks.
            brickGraphics.BeginUnionRect()

            ' Display the image.
            imageBrick = brickGraphics.DrawImage(img, New RectangleF(0, 0, 250, 150), BorderSide.All, Color.Transparent)
            imageBrick.Hint = "Blue Angelfish"
            textBrick = brickGraphics.DrawString("1", Color.Blue, New RectangleF(5, 5, 30, 15), BorderSide.All)
            textBrick.StringFormat = textBrick.StringFormat.ChangeAlignment(StringAlignment.Center)

            ' Display a checkbox.
            checkBrick = brickGraphics.DrawCheckBox(New RectangleF(5, 145, 10, 10), BorderSide.All, Color.White, True)

            ' Create a set of bricks, representing a column with species names.
            brickGraphics.BackColor = Color.FromArgb(153, 204, 255)
            brickGraphics.Font = New Font("Arial", 10, FontStyle.Italic Or FontStyle.Bold Or FontStyle.Underline)
            For i As Integer = 0 To 4

                ' Draw a VisualBrick representing borders for the following TextBrick.
                brick = brickGraphics.DrawRect(New RectangleF(256, 32 * i, 120, 32), BorderSide.All, Color.Transparent, Color.Empty)

                ' Draw the TextBrick with species names.
                textBrick = brickGraphics.DrawString(rows(i), Color.Black, New RectangleF(258, 32 * i + 2, 116, 28), BorderSide.All)
            Next i

            ' Create a set of bricks representing a column with the species characteristics.
            brickGraphics.Font = New Font("Arial", 11, FontStyle.Bold)
            brickGraphics.BackColor = Color.White
            For i As Integer = 0 To 4
                brick = brickGraphics.DrawRect(New RectangleF(376, 32 * i, brickGraphics.ClientPageSize.Width - 376, 32), BorderSide.All, Color.Transparent, brickGraphics.BorderColor)

                ' Draw a TextBrick with species characteristics.
                textBrick = brickGraphics.DrawString(desc(i), Color.Indigo, New RectangleF(378, 32 * i + 2, brickGraphics.ClientPageSize.Width - 380, 28), BorderSide.All)

                ' For text bricks containing numeric data, set text alignment to Far.
                If i < 2 Then
                    textBrick.StringFormat = textBrick.StringFormat.ChangeAlignment(StringAlignment.Far)
                End If
            Next i

            ' Drawing the TextBrick with notes.
            brickGraphics.Font = New Font("Arial", 8)
            brickGraphics.BackColor = Color.Cornsilk
            textBrick = brickGraphics.DrawString(note, Color.Black, New RectangleF(New PointF(0, 160), New SizeF(brickGraphics.ClientPageSize.Width, 40)), BorderSide.All)
            textBrick.StringFormat = textBrick.StringFormat.ChangeLineAlignment(StringAlignment.Near)
            textBrick.Hint = note

            ' Finish the creation of a non-separable group of bricks.
            brickGraphics.EndUnionRect()
        End Sub

        Private Sub Link_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
            ' Specify required settings for the brick graphics.
            Dim brickGraphics As BrickGraphics = e.Graph
            brickGraphics.BackColor = Color.White
            brickGraphics.Font = New Font("Arial", 8)

            ' Declare bricks.
            Dim pageInfoBrick As PageInfoBrick
            Dim pageImageBrick As PageImageBrick

            ' Declare text strings.
            Dim devexpress As String = "XtraPrintingSystem by Developer Express Inc."

            ' Define the image to display.
            Dim pageImage As Image = Image.FromFile("..\..\logo.png")

            ' Display the DevExpress text string.

            Dim size_Renamed As SizeF = brickGraphics.MeasureString(devexpress)
            pageInfoBrick = brickGraphics.DrawPageInfo(PageInfo.None, devexpress, Color.Black, New RectangleF(New PointF(343 - (size_Renamed.Width - pageImage.Width) \ 2, pageImage.Height + 3), size_Renamed), BorderSide.None)
            pageInfoBrick.Alignment = BrickAlignment.Center

            ' Display the PageImageBrick containing the DevExpress logo.
            pageImageBrick = brickGraphics.DrawPageImage(pageImage, New RectangleF(343, 0, pageImage.Width, pageImage.Height), BorderSide.None, Color.Transparent)
            pageImageBrick.Alignment = BrickAlignment.Center

            ' Set the rectangle for a page info brick. 
            Dim r As RectangleF = RectangleF.Empty
            r.Height = 20

            ' Display the PageInfoBrick containing date-time information. Date-time information is displayed
            ' in the left part of the MarginalHeader section using the FullDateTimePattern.
            pageInfoBrick = brickGraphics.DrawPageInfo(PageInfo.DateTime, "{0:F}", Color.Black, r, BorderSide.None)
            pageInfoBrick.Alignment = BrickAlignment.Near

            ' Display the PageInfoBrick containing the page number among total pages. The page number
            ' is displayed in the right part of the MarginalHeader section.
            pageInfoBrick = brickGraphics.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", Color.Black, r, BorderSide.None)
            pageInfoBrick.Alignment = BrickAlignment.Far
        End Sub
    End Class
End Namespace
