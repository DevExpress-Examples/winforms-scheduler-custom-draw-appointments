Imports System
Imports System.Windows.Forms

Namespace CustomDrawDemo

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            DevExpress.Skins.SkinManager.EnableFormSkins()
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
