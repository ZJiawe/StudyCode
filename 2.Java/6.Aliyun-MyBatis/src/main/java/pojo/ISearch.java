package pojo;

import org.apache.ibatis.annotations.Select;

import java.util.List;

public interface ISearch {

    public void serchAllTeacher();

    public List<Teacher> serchAllStudent(int TeacherId);
}
