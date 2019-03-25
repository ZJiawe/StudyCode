package com.qianyu.site.mapper;

import com.qianyu.site.model.User;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.annotations.Select;

public interface IUserMapper {

//   使用注解
//   @Insert("insert t_user (username,password) values (#{username},#{password})")
//    public void save(@Param("username") String username, @Param("password") String password);
//
//    @Select("select * from t_user where id = #{id}")
//    public User getById(@Param("id") Integer id);

//  使用xml文件
public void save(String username,String password);

public User findByUsername(String username);

}
