import org.junit.After;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import java.util.List;

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
        driver.findElement(By.id("hyperlinkLogout")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("admin7");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("adminadmin");
        driver.findElement(By.id("btnSubmit")).click();
        try {
            assertTrue(isElementPresent(By.linkText("test")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        try {
            assertTrue(isElementPresent(By.cssSelector("i.fa.fa-thumbs-o-up")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.cssSelector("i.fa.fa-thumbs-o-up")).click();
        Thread.sleep(2000);
        assertFalse(isElementPresent(By.cssSelector("i.fa.fa-thumbs-o-up")));
        driver.findElement(By.id("hyperlinkLogout")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("houmam");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("btnSubmit")).click();
        try {
            assertTrue(isElementPresent(By.linkText("test")));
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

    @Test
    public void likeTest() throws InterruptedException
    {
        login();
        driver.findElement(By.id("hyperSubmit")).click();
        driver.findElement(By.id("title")).clear();
        driver.findElement(By.id("title")).sendKeys("LikedArtilce");
        driver.findElement(By.id("URL")).clear();
        driver.findElement(By.id("URL")).sendKeys("https://app.asana.com/0/284099359824629/284099359824641");
        driver.findElement(By.id("txt")).clear();
        driver.findElement(By.id("txt")).sendKeys("helloo");
        driver.findElement(By.id("Button1")).click();
        driver.findElement(By.id("hyperlinkLogout")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("admin7");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("adminadmin");
        driver.findElement(By.id("btnSubmit")).click();
        driver.findElement(By.cssSelector("i.fa.fa-thumbs-o-up")).click();
        driver.findElement(By.id("hyperlinkLogout")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("houmam");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("btnSubmit")).click();

        try {
            assertTrue(isElementPresent(By.linkText("LikedArtilce")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.cssSelector("i.fa.fa-heart")).click();
        List heart = driver.findElements(By.xpath("//ol/li[1]/a[1]/i" ));
        assert(heart.size()==0);
    }

    @Test
    public void hideTest() throws  InterruptedException
    {
        login();
        driver.findElement(By.id("hyperSubmit")).click();
        driver.findElement(By.id("title")).clear();
        driver.findElement(By.id("title")).sendKeys("hiddenArticle");
        driver.findElement(By.id("URL")).clear();
        driver.findElement(By.id("URL")).sendKeys("https://www.youtube.com/watch?v=1lyu1KKwC74");
        driver.findElement(By.id("txt")).clear();
        driver.findElement(By.id("txt")).sendKeys("hidden test");
        driver.findElement(By.id("Button1")).click();
        driver.findElement(By.id("hyperlinkLogout")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("admin7");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("adminadmin");
        driver.findElement(By.id("btnSubmit")).click();
        driver.findElement(By.cssSelector("i.fa.fa-thumbs-o-up")).click();
        driver.findElement(By.id("hyperlinkLogout")).click();
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("houmam");
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("btnSubmit")).click();;
        try {
            assertTrue(isElementPresent(By.linkText("hiddenArticle")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        try {
            assertTrue(isElementPresent(By.linkText("hide")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.linkText("hide")).click();
        assertFalse(isElementPresent(By.linkText("hiddenArticle")));

    }

    @Test
    public void commentTest() throws InterruptedException
    {
        login();
        try {
            assertTrue(isElementPresent(By.xpath("//span[2]/a/span")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.xpath("//span[2]/a/span")).click();
        driver.findElement(By.cssSelector("div.container-fluid")).click();
        assertEquals("LikedArtilce", driver.findElement(By.id("articleLink")).getText());
        try {
            assertTrue(isElementPresent(By.id("commText")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        try {
            assertTrue(isElementPresent(By.id("btnComment")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.id("commText")).clear();
        driver.findElement(By.id("commText")).sendKeys("this is a comment");
        driver.findElement(By.id("btnComment")).click();
        driver.findElement(By.id("hyperHome")).click();
        driver.findElement(By.xpath("//span[2]/a/span")).click();
        assertEquals("this is a comment", driver.findElement(By.xpath("//li/div[2]")).getText());
    }

    @Test
    public void changePassTest() throws InterruptedException
    {
        driver.findElement(By.id("hyperLogin")).click();
        driver.findElement(By.id("hlForget")).click();
        driver.findElement(By.id("txtbxEmail")).clear();
        driver.findElement(By.id("txtbxEmail")).sendKeys("hghghghg");
        driver.findElement(By.id("btnSubmit")).click();
        driver.findElement(By.id("txtbxEmail")).clear();
        driver.findElement(By.id("txtbxEmail")).sendKeys("ahmad@ahmad");
        driver.findElement(By.id("btnSubmit")).click();
        try {
            assertTrue(isElementPresent(By.id("lblerrNotFound")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.id("txtbxEmail")).clear();
        driver.findElement(By.id("txtbxEmail")).sendKeys("");
        driver.findElement(By.id("btnSubmit")).click();
        try {
            assertTrue(isElementPresent(By.id("rfvEmail")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.id("txtbxEmail")).clear();
        driver.findElement(By.id("txtbxEmail")).sendKeys("kkk@kkk");
        driver.findElement(By.id("btnSubmit")).click();
        try {
            assertTrue(isElementPresent(By.id("lblSQ")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.id("txtbxSA")).clear();
        driver.findElement(By.id("txtbxSA")).sendKeys("hhhhh");
        driver.findElement(By.id("btnAnswer")).click();
        driver.findElement(By.id("txtbxSA")).clear();
        driver.findElement(By.id("txtbxSA")).sendKeys("");
        driver.findElement(By.id("btnAnswer")).click();
        try {
            assertTrue(isElementPresent(By.id("rfvAnswer")));
        } catch (Error e) {
            verificationErrors.append(e.toString());
        }
        driver.findElement(By.id("txtbxSA")).clear();
        driver.findElement(By.id("txtbxSA")).sendKeys("hassan");
        driver.findElement(By.id("btnAnswer")).click();
        driver.findElement(By.id("btnChange")).click();
        assertEquals("Enter new password", driver.findElement(By.id("rfvPass")).getText());
        driver.findElement(By.id("txtbxPass1")).clear();
        driver.findElement(By.id("txtbxPass1")).sendKeys("123456789");
        driver.findElement(By.id("btnChange")).click();
        assertEquals("Passwords Doesn't match", driver.findElement(By.id("lblMismatch")).getText());
        driver.findElement(By.id("txtbxPass1")).clear();
        driver.findElement(By.id("txtbxPass1")).sendKeys("123456789");
        driver.findElement(By.id("txtbxPass2")).clear();
        driver.findElement(By.id("txtbxPass2")).sendKeys("123456789");
        driver.findElement(By.id("btnChange")).click();
        driver.findElement(By.id("hyperLogin")).click();
        driver.findElement(By.id("txtPass")).clear();
        driver.findElement(By.id("txtPass")).sendKeys("123456789");
        driver.findElement(By.id("txtUser")).clear();
        driver.findElement(By.id("txtUser")).sendKeys("kinan");
        driver.findElement(By.id("btnSubmit")).click();
        assertEquals("Bearvers News", driver.getTitle());
        assertEquals("", driver.findElement(By.id("hyperlinkLogout")).getText());
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
