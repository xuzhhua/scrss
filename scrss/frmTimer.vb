Public Class frmTimer
    Public regMainKey As Microsoft.Win32.RegistryKey
    Public regSubKey As Microsoft.Win32.RegistryKey

    Private Sub txtTimer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimer.KeyPress
        '限制文本框中輸入的字符
        '除去0-9和Backspace以外所有的字符都不允許輸入
        If (Asc(e.KeyChar) < Keys.D0 Or Asc(e.KeyChar) > Keys.D9) And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTimer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTimer.TextChanged
        If Me.txtTimer.Text = vbNullString Or Me.txtTimer.Text = "0" Then
            Me.txtTimer.Text = "3"
        End If
    End Sub

    Private Sub btnSet_Click(sender As System.Object, e As System.EventArgs) Handles btnSet.Click
        isOptionShown = False
        lTimer = CLng(Me.txtTimer.Text)
        regSubKey.SetValue("Timer", lTimer)
        regSubKey.Close()
        regMainKey.Close()
        Me.Hide()
    End Sub

    Private Sub frmTimer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        regMainKey = My.Computer.Registry.CurrentUser
        regSubKey = regMainKey.OpenSubKey("scrss", True)

        If regSubKey Is Nothing Then
            regSubKey = regMainKey.CreateSubKey("scrss", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If

        lTimer = regSubKey.GetValue("Timer")

        If lTimer = vbNull Or lTimer = 0 Then
            isFirst = True
            regSubKey.SetValue("Timer", 3)
            Me.txtTimer.Text = "3"
            lTimer = 3
        Else
            Me.txtTimer.Text = CStr(lTimer)
        End If

    End Sub

    Private Sub frmTimer_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If isFirst = False Then
            regSubKey.Close()
            regMainKey.Close()
            isFirst = True
            Me.Hide()
        End If

        Dim regLoadMainKey As Microsoft.Win32.RegistryKey
        Dim regLoadSubKey As Microsoft.Win32.RegistryKey
        Dim lAutoHide As Long
        Dim strAutoRun As String

        regLoadMainKey = My.Computer.Registry.CurrentUser
        regLoadSubKey = regLoadMainKey.OpenSubKey("scrss", True)

        lAutoHide = regLoadSubKey.GetValue("AutoHide")

        If lAutoHide = 2 Then
            cbAutoHide.Checked = True
        Else
            cbAutoHide.Checked = False
        End If

        regLoadSubKey = regLoadMainKey.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
        strAutoRun = regLoadSubKey.GetValue("scrss")

        If strAutoRun = Nothing Then
            cbAutoRun.Checked = False
        Else
            If strAutoRun.ToUpper = Application.ExecutablePath.ToUpper Then
                cbAutoRun.Checked = True
            Else
                cbAutoRun.Checked = False
            End If
        End If


        regLoadSubKey.Close()
        regLoadMainKey.Close()

    End Sub

    Private Sub cbAutoHide_Click(sender As Object, e As System.EventArgs) Handles cbAutoHide.Click
        Dim regMainKey As Microsoft.Win32.RegistryKey
        Dim regSubKey As Microsoft.Win32.RegistryKey
        'Dim lAutoHide As Long

        regMainKey = My.Computer.Registry.CurrentUser
        regSubKey = regMainKey.OpenSubKey("scrss", True)

        'lAutoHide = regSubKey.GetValue("AutoHide")

        If cbAutoHide.Checked = False Then
            regSubKey.SetValue("AutoHide", 1)
        Else
            regSubKey.SetValue("AutoHide", 2)
        End If

        regSubKey.Close()
        regMainKey.Close()
    End Sub

    Private Sub cbAutoRun_Click(sender As Object, e As System.EventArgs) Handles cbAutoRun.Click
        Dim regMainKey As Microsoft.Win32.RegistryKey
        Dim regSubKey As Microsoft.Win32.RegistryKey

        regMainKey = My.Computer.Registry.CurrentUser
        regSubKey = regMainKey.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        If cbAutoRun.Checked = False Then
            regSubKey.DeleteValue("scrss", False)
        Else
            regSubKey.SetValue("scrss", Application.ExecutablePath.ToUpper)
        End If

        regSubKey.Close()
        regMainKey.Close()
    End Sub
End Class