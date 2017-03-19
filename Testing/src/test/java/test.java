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
        login();
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

    @Test
    public void loginTest() throws InterruptedException
    {
        driver.findElement(By.id("hyperSubmit")).click();
        assertEquals("Login", driver.getTitle());
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("sadsadas");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("asdasdsa");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Wrong Username", driver.findElement(By.id("lblErr1")).getText());
        assertEquals("Wrong Password", driver.findElement(By.id("lblErr2")).getText());
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("houmam");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("btnSubmit")).click();
        driver.findElement(By.id("hyperSubmit")).click();
        assertEquals("Submit", driver.getTitle());
        driver.findElement(By.id("hyperlinkLogout")).click();
        assertEquals("Login", driver.getTitle());
    }

    //Don't forget to delete the test user from DB before starting!
    @Test
    public void registerTest() throws InterruptedException
    {
        driver.findElement(By.id("hyperLogin")).click();
        try {
            assertTrue(driver.findElement(By.id("btnRegister")).isDisplayed());
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.id("btnRegister")).click();
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Invalid Username", driver.findElement(By.id("lblErr1")).getText());
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("houmam");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Invalid Password", driver.findElement(By.id("lblErr2")).getText());
        driver.findElement(By.id("txtEmail")).clear();
        driver.findElement(By.id("txtEmail")).sendKeys("aaaaa");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("btnSubmit")).click();
        driver.findElement(By.id("txtEmail")).clear();
        driver.findElement(By.id("txtEmail")).sendKeys("aaaaa@aaaa");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Invalid Security Question", driver.findElement(By.id("lblQErr")).getText());
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("txtQ")).clear();
        driver.findElement(By.id("txtQ")).sendKeys("aaaaaaaaaaaa");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Invalid Answer", driver.findElement(By.id("lblAErr")).getText());
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("aaaaaaaaaa");
        driver.findElement(By.id("txtA")).clear();
        driver.findElement(By.id("txtA")).sendKeys("aaaaaaaaaaaa");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Used Username", driver.findElement(By.id("lblErr1")).getText());
        assertEquals("Used Email", driver.findElement(By.id("lblEmailErr")).getText());
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("test");
        driver.findElement(By.id("txtEmail")).clear();
        driver.findElement(By.id("txtEmail")).sendKeys("test@test");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("testtest");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Invalid Username", driver.findElement(By.id("lblErr1")).getText());
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("testtest");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("testtest");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Login", driver.getTitle());
        Thread.sleep(5000);
        driver.findElement(By.id("txtUser")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("testtest");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("testtest");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Bearvers News", driver.getTitle());
        driver.findElement(By.id("hyperSubmit")).click();
        assertEquals("Submit", driver.getTitle());
        driver.findElement(By.id("hyperlinkLogout")).click();
        assertEquals("Login", driver.getTitle());
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
