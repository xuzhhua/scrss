Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmMain
    Private Declare Auto Function keybd_event Lib "user32.dll" Alias "keybd_event" _
    (ByVal bVk As System.Int16, ByVal bScan As System.Int16, ByVal dwFlags As System.Int32, ByVal dwExtraInfo As System.Int16) As Long

    Private Const VK_F24 = &H87

    Private contextMenuMain As System.Windows.Forms.ContextMenu
    Friend WithEvents iMenuStart As System.Windows.Forms.MenuItem
    Friend WithEvents iMenuStop As System.Windows.Forms.MenuItem
    Friend WithEvents iMenuExit As System.Windows.Forms.MenuItem
    Friend WithEvents iMenuHideIcon As System.Windows.Forms.MenuItem
    Friend WithEvents iMenuSSS As System.Windows.Forms.MenuItem
    Friend WithEvents iMenuSSS1 As System.Windows.Forms.MenuItem
    Friend WithEvents iMenuOption As System.Windows.Forms.MenuItem

    Friend WithEvents notifyIcon_Main As System.Windows.Forms.NotifyIcon
    Private componentsMain As System.ComponentModel.IContainer

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TimerMain.Interval = 175000
        'TimerMain.Enabled = True
        isOptionShown = False
        Me.componentsMain = New System.ComponentModel.Container
        Me.contextMenuMain = New System.Windows.Forms.ContextMenu
        Me.iMenuStart = New System.Windows.Forms.MenuItem
        Me.iMenuStop = New System.Windows.Forms.MenuItem
        Me.iMenuExit = New System.Windows.Forms.MenuItem
        Me.iMenuHideIcon = New System.Windows.Forms.MenuItem
        Me.iMenuSSS = New System.Windows.Forms.MenuItem
        Me.iMenuSSS1 = New System.Windows.Forms.MenuItem
        Me.iMenuOption = New System.Windows.Forms.MenuItem

        ' Initialize contextMenuMain
        Me.contextMenuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
                            {Me.iMenuStart, Me.iMenuStop, Me.iMenuHideIcon, Me.iMenuSSS, Me.iMenuOption, Me.iMenuSSS1, Me.iMenuExit})

        Me.iMenuStart.Text = "Start"
        Me.iMenuStart.Index = 0
        Me.iMenuStop.Text = "Stop"
        Me.iMenuStop.Index = 1
        Me.iMenuHideIcon.Text = "Hide"
        Me.iMenuHideIcon.Index = 2
        Me.iMenuSSS.Text = "-"
        Me.iMenuSSS.Index = 3
        Me.iMenuOption.Text = "Option"
        Me.iMenuOption.Index = 4
        Me.iMenuSSS1.Text = "-"
        Me.iMenuSSS1.Index = 5
        Me.iMenuExit.Text = "Exit"
        Me.iMenuExit.Index = 6

        'Me.ClientSize = New System.Drawing.Size(292, 266)
        'Me.Text = "Notify Icon Example"

        'Dim resIcon As Resources.ResourceManager = My.Resources.ResourceManager

        Me.notifyIcon_Main = New System.Windows.Forms.NotifyIcon(Me.componentsMain)
        'Me.notifyIcon_Main.Icon = resIcon.GetObject("sync")
        Me.notifyIcon_Main.Icon = My.Resources.sync
        notifyIcon_Main.ContextMenu = Me.contextMenuMain

        notifyIcon_Main.Text = ""
        notifyIcon_Main.Visible = True

        AddHandler iMenuStart.Click, AddressOf Me.btnStart_Click
        AddHandler iMenuStop.Click, AddressOf Me.btnStop_Click
        AddHandler iMenuHideIcon.Click, AddressOf Me.btnHide_Click
        AddHandler iMenuOption.Click, AddressOf Me.btnOption_Click
        AddHandler iMenuExit.Click, AddressOf Me.btnExit_Click

        isFirst = False
        TimerMain.Enabled = False

        Dim regMainKey As Microsoft.Win32.RegistryKey
        Dim regSubKey As Microsoft.Win32.RegistryKey
        Dim lAutoHide As Long

        regMainKey = My.Computer.Registry.CurrentUser
        regSubKey = regMainKey.OpenSubKey("scrss", True)

        lAutoHide = regSubKey.GetValue("AutoHide")
        regSubKey.Close()
        regMainKey.Close()

        If lAutoHide = vbNull Or 0 Then
        Else
            If lAutoHide = 2 Then
                notifyIcon_Main.Visible = False
            End If
        End If
    End Sub

    Private Sub TimerMain_Tick(sender As System.Object, e As System.EventArgs) Handles TimerMain.Tick
        keybd_event(VK_F24, 0, 1 Or 0, 0)
        keybd_event(VK_F24, 0, 1 Or 2, 0)
        'SendKeys.Send("{NUMLOCK}")
        'SendKeys.Send("{NUMLOCK}")
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Hide()
        Dim frmT As New frmTimer
        frmT.ShowDialog()

        If lTimer = 0 Then
            TimerMain.Interval = 0
            TimerMain.Enabled = False
            iMenuStop.Enabled = False
            iMenuStart.Enabled = True
        Else
            TimerMain.Interval = lTimer * 60 * 1000 - 5000
            TimerMain.Enabled = True
            iMenuStop.Enabled = True
            iMenuStart.Enabled = False
        End If
    End Sub

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.notifyIcon_Main.Dispose()
        TimerMain.Enabled = False
        End
    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        If lTimer = 0 Then
        Else
            TimerMain.Enabled = True
            iMenuStop.Enabled = True
            iMenuStart.Enabled = False
        End If
    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        TimerMain.Enabled = False
        iMenuStop.Enabled = False
        iMenuStart.Enabled = True
    End Sub

    Private Sub btnHide_Click(sender As System.Object, e As System.EventArgs) Handles btnHide.Click
        notifyIcon_Main.Visible = False
    End Sub

    Private Sub btnOption_Click(sender As System.Object, e As System.EventArgs) Handles btnOption.Click
        If isOptionShown = False Then
            TimerMain.Enabled = False
            isOptionShown = True

            Dim frmT As New frmTimer
            frmT.ShowDialog()

            If lTimer = 0 Then
                TimerMain.Interval = 0
                TimerMain.Enabled = False
                iMenuStop.Enabled = False
                iMenuStart.Enabled = True
            Else
                TimerMain.Interval = lTimer * 60 * 1000 - 5000
                TimerMain.Enabled = True
                iMenuStop.Enabled = True
                iMenuStart.Enabled = False
            End If
        End If
    End Sub
End Class
