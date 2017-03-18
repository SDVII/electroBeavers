import org.junit.After;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import static org.junit.Assert.*;

/**
 * Created by houma on 18-Mar-17.
 */
public class test extends baseTest
{

    private StringBuffer verificationErrors = new StringBuffer();

    @Test
    public void submitTest() throws InterruptedException
    {
        driver.findElement(By.id("hyperSubmit")).click();
        driver.findElement(By.id("Button1")).click();
        try {
            assertEquals("Error !!", driver.findElement(By.id("Label1")).getText());
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }

        driver.findElement(By.id("title")).clear();
        driver.findElement(By.id("title")).sendKeys("test");
        driver.findElement(By.id("URL")).clear();
        driver.findElement(By.id("URL")).sendKeys("http://test.test");
        driver.findElement(By.id("txt")).clear();
        driver.findElement(By.id("txt")).sendKeys("test");
        driver.findElement(By.id("Button1")).click();
        try {
            assertEquals("Your Article was Added Successfully", driver.findElement(By.id("Label1")).getText());
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }

        driver.findElement(By.id("hyperHome")).click();
        WebElement article = driver.findElement(By.xpath("//ol/li[1]/a[@class='title']"));
        try {
            assertEquals("test", article.getText());
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }

    }

    @Test
    public void newsTest() throws InterruptedException
    {
        try {
            assertTrue(driver.findElements(By.xpath("//ol/li")).size()!=0);
        }   catch (Error e) {
            verificationErrors.append(e.toString());
        }
    }

    @After
    public void tearDown() throws Exception {
        driver.quit();
        String verificationErrorString = verificationErrors.toString();
        if (!"".equals(verificationErrorString)) {
            fail(verificationErrorString);
        }
    }

}
