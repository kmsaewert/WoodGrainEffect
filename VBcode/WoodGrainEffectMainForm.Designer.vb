<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WoodGrainEffectMainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WoodGrainEffectMainForm))
        FolderBrowserDialog1 = New FolderBrowserDialog()
        lblMainTitle = New Label()
        btnRunNow = New Button()
        tboxCuraFile = New TextBox()
        btnBrowseCuraFile = New Button()
        lblChooseCuraFile = New Label()
        lblSavePath = New Label()
        tboxSaveAs = New TextBox()
        btnBrowseSaveAs = New Button()
        lblTopNotes = New Label()
        lblBottomNotes = New Label()
        tboxTopTemp = New TextBox()
        lblTopTemp = New Label()
        tboxBottomTemp = New TextBox()
        lblBottomTemp = New Label()
        tboxStatus = New TextBox()
        SuspendLayout()
        ' 
        ' lblMainTitle
        ' 
        lblMainTitle.AccessibleName = "lblMainTitle"
        lblMainTitle.AutoSize = True
        lblMainTitle.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMainTitle.Location = New Point(12, 9)
        lblMainTitle.Name = "lblMainTitle"
        lblMainTitle.Size = New Size(341, 21)
        lblMainTitle.TabIndex = 0
        lblMainTitle.Text = "Add Wood Grain Effect to a Cura GCode File"
        ' 
        ' btnRunNow
        ' 
        btnRunNow.AccessibleName = "btnRunNow"
        btnRunNow.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnRunNow.Location = New Point(543, 404)
        btnRunNow.Name = "btnRunNow"
        btnRunNow.Size = New Size(75, 23)
        btnRunNow.TabIndex = 1
        btnRunNow.Text = "Run Now"
        btnRunNow.UseVisualStyleBackColor = True
        ' 
        ' tboxCuraFile
        ' 
        tboxCuraFile.Location = New Point(12, 189)
        tboxCuraFile.Name = "tboxCuraFile"
        tboxCuraFile.Size = New Size(283, 23)
        tboxCuraFile.TabIndex = 2
        ' 
        ' btnBrowseCuraFile
        ' 
        btnBrowseCuraFile.Location = New Point(301, 189)
        btnBrowseCuraFile.Name = "btnBrowseCuraFile"
        btnBrowseCuraFile.Size = New Size(63, 23)
        btnBrowseCuraFile.TabIndex = 3
        btnBrowseCuraFile.Text = "browse..."
        btnBrowseCuraFile.UseVisualStyleBackColor = True
        ' 
        ' lblChooseCuraFile
        ' 
        lblChooseCuraFile.AutoSize = True
        lblChooseCuraFile.Location = New Point(12, 171)
        lblChooseCuraFile.Name = "lblChooseCuraFile"
        lblChooseCuraFile.Size = New Size(193, 15)
        lblChooseCuraFile.TabIndex = 4
        lblChooseCuraFile.Text = "Choose the original Cura gcode file"
        ' 
        ' lblSavePath
        ' 
        lblSavePath.AutoSize = True
        lblSavePath.Location = New Point(12, 234)
        lblSavePath.Name = "lblSavePath"
        lblSavePath.Size = New Size(354, 15)
        lblSavePath.TabIndex = 5
        lblSavePath.Text = "Choose a folder and file name of where to save the new gcode file"
        ' 
        ' tboxSaveAs
        ' 
        tboxSaveAs.Location = New Point(12, 252)
        tboxSaveAs.Name = "tboxSaveAs"
        tboxSaveAs.Size = New Size(283, 23)
        tboxSaveAs.TabIndex = 6
        ' 
        ' btnBrowseSaveAs
        ' 
        btnBrowseSaveAs.Location = New Point(301, 252)
        btnBrowseSaveAs.Name = "btnBrowseSaveAs"
        btnBrowseSaveAs.Size = New Size(63, 23)
        btnBrowseSaveAs.TabIndex = 7
        btnBrowseSaveAs.Text = "browse..."
        btnBrowseSaveAs.UseVisualStyleBackColor = True
        ' 
        ' lblTopNotes
        ' 
        lblTopNotes.AutoSize = True
        lblTopNotes.Location = New Point(12, 30)
        lblTopNotes.Name = "lblTopNotes"
        lblTopNotes.Size = New Size(594, 105)
        lblTopNotes.TabIndex = 8
        lblTopNotes.Text = resources.GetString("lblTopNotes.Text")
        ' 
        ' lblBottomNotes
        ' 
        lblBottomNotes.AutoSize = True
        lblBottomNotes.Location = New Point(12, 390)
        lblBottomNotes.Name = "lblBottomNotes"
        lblBottomNotes.Size = New Size(364, 45)
        lblBottomNotes.TabIndex = 9
        lblBottomNotes.Text = "* This app assumes the gcode file it is starting with, is a basic output" & vbCrLf & "from Cura with one temperature throughout the print and no " & vbCrLf & "extensions altering the sliced code."
        ' 
        ' tboxTopTemp
        ' 
        tboxTopTemp.Location = New Point(12, 294)
        tboxTopTemp.Name = "tboxTopTemp"
        tboxTopTemp.Size = New Size(37, 23)
        tboxTopTemp.TabIndex = 10
        tboxTopTemp.Text = "240"
        ' 
        ' lblTopTemp
        ' 
        lblTopTemp.AutoSize = True
        lblTopTemp.Location = New Point(55, 297)
        lblTopTemp.Name = "lblTopTemp"
        lblTopTemp.Size = New Size(225, 15)
        lblTopTemp.TabIndex = 11
        lblTopTemp.Text = "Highest Temperature (C) [typical is 240 C]"
        ' 
        ' tboxBottomTemp
        ' 
        tboxBottomTemp.Location = New Point(12, 323)
        tboxBottomTemp.Name = "tboxBottomTemp"
        tboxBottomTemp.Size = New Size(37, 23)
        tboxBottomTemp.TabIndex = 12
        tboxBottomTemp.Text = "190"
        ' 
        ' lblBottomTemp
        ' 
        lblBottomTemp.AutoSize = True
        lblBottomTemp.Location = New Point(55, 326)
        lblBottomTemp.Name = "lblBottomTemp"
        lblBottomTemp.Size = New Size(221, 15)
        lblBottomTemp.TabIndex = 13
        lblBottomTemp.Text = "Lowest Temperature (C) [typical is 190 C]"
        ' 
        ' tboxStatus
        ' 
        tboxStatus.Location = New Point(393, 171)
        tboxStatus.Multiline = True
        tboxStatus.Name = "tboxStatus"
        tboxStatus.ReadOnly = True
        tboxStatus.ScrollBars = ScrollBars.Vertical
        tboxStatus.Size = New Size(225, 213)
        tboxStatus.TabIndex = 14
        tboxStatus.Text = "Status and progress will show here:"
        ' 
        ' WoodGrainEffectMainForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(636, 444)
        Controls.Add(tboxStatus)
        Controls.Add(lblBottomTemp)
        Controls.Add(tboxBottomTemp)
        Controls.Add(lblTopTemp)
        Controls.Add(tboxTopTemp)
        Controls.Add(lblBottomNotes)
        Controls.Add(lblTopNotes)
        Controls.Add(btnBrowseSaveAs)
        Controls.Add(tboxSaveAs)
        Controls.Add(lblSavePath)
        Controls.Add(lblChooseCuraFile)
        Controls.Add(btnBrowseCuraFile)
        Controls.Add(tboxCuraFile)
        Controls.Add(btnRunNow)
        Controls.Add(lblMainTitle)
        Name = "WoodGrainEffectMainForm"
        Text = "Wood Grain Effect  (created by Kirk Saewert)"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblMainTitle As Label
    Friend WithEvents btnRunNow As Button
    Friend WithEvents tboxCuraFile As TextBox
    Friend WithEvents btnBrowseCuraFile As Button
    Friend WithEvents lblChooseCuraFile As Label
    Friend WithEvents lblSavePath As Label
    Friend WithEvents tboxSaveAs As TextBox
    Friend WithEvents btnBrowseSaveAs As Button
    Friend WithEvents lblTopNotes As Label
    Friend WithEvents lblBottomNotes As Label
    Friend WithEvents tboxTopTemp As TextBox
    Friend WithEvents lblTopTemp As Label
    Friend WithEvents tboxBottomTemp As TextBox
    Friend WithEvents lblBottomTemp As Label
    Friend WithEvents tboxStatus As TextBox

End Class
