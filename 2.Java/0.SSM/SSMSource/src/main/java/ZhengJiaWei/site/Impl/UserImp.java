package ZhengJiaWei.site.Impl;

import ZhengJiaWei.site.ioc.UserDao;
import org.springframework.stereotype.Repository;

@Repository("userDao")
public class UserImp implements UserDao {
    public void say() {
        System.out.println("Hello World!");
    }
}
