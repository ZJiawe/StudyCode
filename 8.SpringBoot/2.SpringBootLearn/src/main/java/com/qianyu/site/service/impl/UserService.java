package com.qianyu.site.service.impl;

import com.qianyu.site.service.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Service;

@Service
public class UserService implements IUserService {
    @Autowired
    private JdbcTemplate jdbcTemplate;


    @Override
    public void register(String username, String password) {
        String sql = "insert t_user (username, password) values (?,?)";
        jdbcTemplate.update(sql,username,password);
    }


}
