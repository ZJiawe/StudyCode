package com.qianyu.site.service.impl;

import com.qianyu.site.mapper.IUserMapper;
import com.qianyu.site.model.User;
import com.qianyu.site.service.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class UserService2 implements IUserService {
    @Autowired
    private JdbcTemplate jdbcTemplate;
    @Autowired
    private  IUserMapper iUserMapper;

//  通过SpringJDBC实现
    @Override
    public void register(String username, String password) {
        String sql = "insert t_user (username, password) values (?,?)";
        jdbcTemplate.update(sql,username,password);
    }

//    通过Mybatis实现
    public void save(String username, String password) {
        iUserMapper.save(username,password);
        System.out.println("test");
    }

    public User getById(String name) {
        User user = iUserMapper.findByUsername(name);
        System.out.println("Service2");
        return user;
    }
}
