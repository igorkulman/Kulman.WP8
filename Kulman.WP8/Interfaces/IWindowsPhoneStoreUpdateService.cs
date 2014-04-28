namespace Kulman.WP8.Interfaces
{
    public interface IWindowsPhoneStoreUpdateService
    {
        /// <summary>
        /// Checks the Windows Phone Store to see if a newer version of the app is available
        /// If it is, a dialog is shown
        /// </summary>
        /// <param name="updateDialogText">Dialog text</param>
        /// <param name="updateDialogTitle">Dialog title</param>
        void CheckForUpdatedVersion(string updateDialogText, string updateDialogTitle);
    }
}
