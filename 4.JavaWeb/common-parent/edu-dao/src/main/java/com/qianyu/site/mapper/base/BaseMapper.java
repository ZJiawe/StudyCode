package com.qianyu.site.mapper.base;

import java.util.List;

public interface BaseMapper<T>{
    T findById(int id);
    T findByUUId(String uuid);
    List<T> listBySearch();
    void deleteById(int id);
    void deleteByUUId(String uuid);
    void insert(T t);
    void update(T t);
}
