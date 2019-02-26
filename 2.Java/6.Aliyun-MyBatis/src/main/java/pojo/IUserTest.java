package pojo;

import org.apache.ibatis.annotations.Delete;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Select;
import org.apache.ibatis.annotations.Update;

import java.util.List;

public interface IUserTest {
    @Select("select * from  user where idUser = #{id}")
    public User getById(int id);
    @Insert("select * from  user where idUser = #{id}")
    public void addUser(User user);
    @Delete(" delete from user where idUser = #{id}")
    public void deleteUser(int id);
    @Update("update user set idUser = #{idUser},name=#{name},age = #{age}\n" +
            "        where  idUser = #{idUser}")
    public void updateUser(User user);
    @Select(" select * from user")
    public List<User> selectAllUser();
    @Select("select * from user limit #{startIndex},#{pageNum}")
    public List<User> selectAllUserBySort(Integer startIndex, Integer pageNum);
}
