using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UnPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // --- 🚨 CONTROL DE PRIVILEGIOS AL INICIAR ---
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string tituloPrompt = "🤔Privilegios";
                string mensajePrompt = "¿Recordaste abrirme con ejecutar como admin/AdvancedRun/NSudo system para disfrutar este panel al máximo? Si no, puede ser que algo falle.\n\n" +
                                       "Sí = Abrir              No = Pedir UAC (se honesto)";

                DialogResult resultado = MessageBox.Show(mensajePrompt, tituloPrompt, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    ProcessStartInfo elevarUAC = new ProcessStartInfo();
                    elevarUAC.FileName = Application.ExecutablePath;
                    elevarUAC.Verb = "runas";
                    elevarUAC.UseShellExecute = true;
                    try { Process.Start(elevarUAC); Application.Exit(); }
                    catch { MessageBox.Show("Operación abortada. Modo estándar activo.", "⚠️"); }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de inicio: " + ex.Message); }
        }

        private void EjecutarCmd(string argumentos, string mensajeExito)
        {
            try
            {
                Process startInfo = new Process();
                startInfo.StartInfo.FileName = "cmd.exe";
                startInfo.StartInfo.Arguments = "/c " + argumentos;
                startInfo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Start();
                if (!string.IsNullOrEmpty(mensajeExito)) MessageBox.Show(mensajeExito, "🛸 TELEMETRÍA ALIENÍGENA");
            }
            catch (Exception ex) { MessageBox.Show("Error de transistores: " + ex.Message); }
        }

        // --- BLOQUE 1: LIMPIEZA ---
        private void button1_Click(object sender, EventArgs e) { EjecutarCmd("del /q /f /s %temp%\\* && del /q /f /s C:\\Windows\\Temp\\*", "Búnker multimedia desinfectado. Temporales purgados."); }
        private void button2_Click(object sender, EventArgs e) { EjecutarCmd("rd /s /q %systemdrive%\\$Recycle.Bin", "Papelera de reciclaje pulverizada de la memoria."); }
        private void button3_Click(object sender, EventArgs e) { Process.Start("cleanmgr.exe", "/sagerun:1"); }
        private void button4_Click(object sender, EventArgs e) { EjecutarCmd("del /f /q /s C:\\*.tmp && del /f /q /s C:\\*.log", "Archivos .tmp y .log evaporados."); }
        private void button5_Click(object sender, EventArgs e) { EjecutarCmd("net stop wuauserv && rd /s /q %systemroot%\\SoftwareDistribution && net start wuauserv", "Caché de Windows Update purgada al 100%."); }

        // --- BLOQUE 2: RED ---
        private void button6_Click(object sender, EventArgs e) { EjecutarCmd("ipconfig /flushdns", "Caché de red purgada al cero absoluto de lag."); }
        private void button7_Click(object sender, EventArgs e) { EjecutarCmd("netsh winsock reset && netsh int ip reset", "Pila de red e interfaces Wi-Fi reanimadas."); }
        private void button8_Click(object sender, EventArgs e) { EjecutarCmd("netsh int tcp set global autotuninglevel=normal", "Ping optimizado para contrabando multimedia."); }
        private void button9_Click(object sender, EventArgs e) { EjecutarCmd("netsh int ipv6 set state disabled", "IPv6 deshabilitado. Carril IPv4 estabilizado."); }
        private void button10_Click(object sender, EventArgs e) { EjecutarCmd("netsh int tcp set global congestionprovider=ctcp", "Ancho de banda liberado de los límites de Microsoft."); }

        // --- BLOQUE 3: SEGURIDAD Y DIAGNÓSTICO ---
        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Reiniciar para ir directo a la BIOS UEFI?", "🚨", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Process.Start(new ProcessStartInfo("shutdown.exe", "/r /fw /t 0") { WindowStyle = ProcessWindowStyle.Hidden });
        }
        private void button12_Click(object sender, EventArgs e) { Process.Start("cmd.exe", "/k chkdsk C:"); }
        private void button13_Click(object sender, EventArgs e) { EjecutarCmd("\"C:\\Program Files\\Windows Defender\\MpCmdRun.exe\" -Scan -ScanType 1", "Escáner rápido de Windows Defender ejecutándose en la sombra."); }
        private void button14_Click(object sender, EventArgs e) { Process.Start("cmd.exe", "/k sfc /scannow"); }
        private void button15_Click(object sender, EventArgs e) { Process.Start("cmd.exe", "/k DISM /Online /Cleanup-Image /RestoreHealth"); }

        // --- BLOQUE 4: RENDIMIENTO Y BLOATWARE ---
        private void button16_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", "AutoRestartShell", 0, Microsoft.Win32.RegistryValueKind.DWord);
            foreach (var p in Process.GetProcessesByName("explorer")) p.Kill();
            MessageBox.Show("Modo Vengadores consolidado. Escritorio apagado.", "🛸");
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", "AutoRestartShell", 1, Microsoft.Win32.RegistryValueKind.DWord);
            Process.Start("explorer.exe");
        }
        private void button18_Click(object sender, EventArgs e)
        {
            string cmdsc = "sc stop DiagTrack && sc delete DiagTrack && sc stop dmwappushservice && sc delete dmwappushservice && sc stop RetailDemo && sc delete RetailDemo && sc stop WerSvc && sc config WerSvc start= disabled && sc stop PcaSvc && sc config PcaSvc start= disabled && sc stop MapsBroker && sc config MapsBroker start= disabled && sc stop XblAuthManager && sc config XblAuthManager start= disabled && sc stop XblGameSave && sc config XblGameSave start= disabled && sc stop XboxNetApiSvc && sc config XboxNetApiSvc start= disabled";
            EjecutarCmd(cmdsc, "Aplanadora quirúrgica impactada. 10 servicios de telemetría y Xbox eliminados.");
        }
        private void button19_Click(object sender, EventArgs e) { EjecutarCmd("powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61", "Esquema oculto de Máxima Energía duplicado con éxito."); }
        private void button20_Click(object sender, EventArgs e) { EjecutarCmd("reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search\" /v AllowCortana /t REG_DWORD /d 0 /f", "Cortana y asistentes espías revocados de la memoria."); }

        // --- APOYOS ---
        private void button_k_Click(object sender, EventArgs e) { Process.Start(new ProcessStartInfo { FileName = "https://youtube.com/@kojiroXD", UseShellExecute = true }); }
        private void button_w_Click(object sender, EventArgs e) { Process.Start(new ProcessStartInfo { FileName = "https://youtube.com/@Windows", UseShellExecute = true }); }
        private void button_e_Click(object sender, EventArgs e) { Process.Start(new ProcessStartInfo { FileName = "https://github.com/Endermanch/MalwareDatabase", UseShellExecute = true }); }
        private void pictureBox1_Click(object sender, EventArgs e) { MessageBox.Show("Alien operando al 1% de CPU nativo. ¡Hecho por KojiroXD!", "🛸 Easter Egg listo :)"); }
    }
}
