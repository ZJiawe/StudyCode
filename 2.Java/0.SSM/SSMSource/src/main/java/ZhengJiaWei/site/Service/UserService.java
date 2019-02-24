package ZhengJiaWei.site.Service;

import ZhengJiaWei.site.ioc.UserDao;
import org.springframework.stereotype.Service;


import javax.annotation.Resource;

@Service("userService")
public class UserService implements UserDao {
    @Resource(name = "userDao")
    private UserDao userDao;

    public void setUserDao(UserDao userDao) {
        this.userDao = userDao;
    }


    //代理类作用say
    public void say() {
        this.userDao.say();
        System.out.println(userDao.getClass()+":正在运行。。。");
    }
}
