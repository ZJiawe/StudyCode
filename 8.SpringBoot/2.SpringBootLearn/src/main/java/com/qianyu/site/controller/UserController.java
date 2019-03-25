package com.qianyu.site.controller;

import com.qianyu.site.mapper.IUserMapper;
import com.qianyu.site.model.User;
import com.qianyu.site.service.IUserService;
import com.qianyu.site.service.impl.UserService;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController()
@RequestMapping("user")
public class UserController {

    @Autowired
    private IUserService userService;
    Logger logger = Logger.getLogger(UserController.class);

    @RequestMapping("{id}")
    @ResponseBody()
    public User getUser(@PathVariable() Integer id){
        User user = new User();
        user.setId(id);
        user.setUserName("郑嘉伟");
        user.setUserAge("15");
        return user;
    }

    @RequestMapping("register")
    @ResponseBody
    public String registerUser(String username, String password){
        userService.register(username,password);
        return "Succeess!";
    }

    @RequestMapping("save")
    @ResponseBody
    public String saveUser(String username, String password){
        userService.save(username,password);
        return "Succeess!";
    }

    @RequestMapping("get")
    @ResponseBody
    public User getById(String username ){
        logger.info("==========" + "find BY UserName" + username);
        User user =  userService.getById(username);
        return user;
    }
}
