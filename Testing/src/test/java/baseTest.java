import org.junit.*;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import java.util.concurrent.TimeUnit;

/**
 * Created by houma on 18-Mar-17.
 */
public class baseTest
{
    public WebDriver driver;
    private String baseUrl;


    @Before
    public void setUp() throws Exception
    {
        System.setProperty("webdriver.chrome.driver", "driver/chromedriver.exe");
        driver = new ChromeDriver();
        baseUrl = "http://localhost:58692/homepage.aspx";
        driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
        driver.get(baseUrl + "/logout.aspx");
        driver.get(baseUrl + "/");
    }

    public void login()
    {
        driver.findElement(By.id("hyperLogin")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("houmam");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("btnSubmit")).click();
    }

}
