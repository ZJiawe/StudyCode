package com.qianyu.site.service;

import com.qianyu.site.model.User;

public interface IUserService {
    void register(String username, String password);
    void save(String username, String password);
    User getById(String username);
}
