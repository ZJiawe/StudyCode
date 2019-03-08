package com.qianyu.site.service.interfaces;

import com.qianyu.site.Model.User;
import com.qianyu.site.service.base.IBaseService;

public interface IUserService extends IBaseService<User> {
    //添加独有的方法
    public User Login(String account, String password);
}
