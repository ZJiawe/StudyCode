package com.qianyu.site.mapper;

import com.qianyu.site.mapper.model.SalaryDetail;
import com.qianyu.site.mapper.model.SalaryDetailExample;
import java.util.List;
import org.apache.ibatis.annotations.Param;

public interface SalaryDetailMapper {
    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int countByExample(SalaryDetailExample example);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int deleteByExample(SalaryDetailExample example);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int deleteByPrimaryKey(String id);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int insert(SalaryDetail record);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int insertSelective(SalaryDetail record);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    List<SalaryDetail> selectByExample(SalaryDetailExample example);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    SalaryDetail selectByPrimaryKey(String id);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int updateByExampleSelective(@Param("record") SalaryDetail record, @Param("example") SalaryDetailExample example);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int updateByExample(@Param("record") SalaryDetail record, @Param("example") SalaryDetailExample example);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int updateByPrimaryKeySelective(SalaryDetail record);

    /**
     * This method was generated by MyBatis Generator.
     * This method corresponds to the database table t_salary_detail
     *
     * @mbggenerated Sun Mar 10 14:34:22 CST 2019
     */
    int updateByPrimaryKey(SalaryDetail record);
}