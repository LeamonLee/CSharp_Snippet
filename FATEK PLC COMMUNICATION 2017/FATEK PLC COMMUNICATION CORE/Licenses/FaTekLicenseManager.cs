using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialNetworks.FatekCom.Licenses
{
    public static class FaTekLicenseManager
    {
        private static string _License;

        public static string MessageLicense = " FATEK PLC Communnication Protocol With C#: Trial Period Expires.\n Mr: HOANG VAN LUU.\n Please contacts with Industrial Networks.\n Skype: katllu.\n Mobile: 0909.886.483.\n Email: hoangluu.automation@gmail.com";

        private static LicenseForm objLicenseForm = null;

        public static string License
        {
            get
            {
                return _License;
            }
            set
            {
                if ("HoangLuu#2006@VN-Luu*010883+YOU$2015=Value!".Equals(value)) FaTekLicenseManager._License = "OK";
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv"
                || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "VCSExpress"
                || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "vbexpress"
                    || System.Diagnostics.Process.GetCurrentProcess().ProcessName == "WDExpress")
                    return true;
                else return false;
            }
        }



        public static void ShowLicenseForm()
        {
            if (objLicenseForm == null) objLicenseForm = new LicenseForm();
            if (objLicenseForm.Visible) return;
            objLicenseForm.ShowInTaskbar = false;
            objLicenseForm.TopMost = true;
            objLicenseForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            objLicenseForm.ShowDialog();
        }
    }
}
