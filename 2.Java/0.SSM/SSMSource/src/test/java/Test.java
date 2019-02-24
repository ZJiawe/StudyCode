import ZhengJiaWei.site.Service.UserService;
import ZhengJiaWei.site.constructor.Bean1;
import ZhengJiaWei.site.ioc.UserDao;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class Test {
    @org.junit.Test
    public void test(){
        ApplicationContext applicationContext = new ClassPathXmlApplicationContext("applicationContext.xml");
        UserService userDao = (UserService) applicationContext. getBean("userService");
        userDao.say();
    }

    @org.junit.Test
    public void Bean(){
        ApplicationContext applicationContext = new ClassPathXmlApplicationContext("applicationContext.xml");
        Bean1 bean1 = (Bean1)applicationContext.getBean("Bean1");
        System.out.println(bean1);
    }

}
