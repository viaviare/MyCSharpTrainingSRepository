namespace litecart
{
	public class NavigationHelper : HelperBase
	{
		private string baseURL;

		public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
		{
			this.baseURL = baseURL;
		}

		public void OpenStartPage()
		{
			driver.Navigate().GoToUrl(baseURL + "/login.php");			
		}
	}
}