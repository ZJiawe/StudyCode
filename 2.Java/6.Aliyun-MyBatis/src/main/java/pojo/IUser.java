package pojo;

import java.util.List;

public interface IUser {
    public User getById(int id);
    public void addUser(User user);
    public void deleteUser(int id);
    public void updateUser(User user);
    public List<User> selectAllUser();
    public List<User> selectAllUserBySort(Integer startIndex,Integer pageNum);
    public List<User> selectByCondition();
}
