package pojo;


public class Student {

  private long id;
  private String name;
  private long tId;
  public Teacher teacher;

  @Override
  public String toString() {
    return "Student: "+this.getName()+";Teacher: "+ this.getTeacher().getName();
  }

  public Teacher getTeacher() {
    return teacher;
  }

  public void setTeacher(Teacher teacher) {
    this.teacher = teacher;
  }



  public long getId() {
    return id;
  }

  public void setId(long id) {
    this.id = id;
  }


  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }


  public long getTId() {
    return tId;
  }

  public void setTId(long tId) {
    this.tId = tId;
  }

}
