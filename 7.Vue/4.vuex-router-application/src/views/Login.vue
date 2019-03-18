<template>
  <div>
    <form v-if="isReg" >
      <tr>用户名：</tr>
      <tr><input type="text" v-model="username"></tr>
      <tr>密码：</tr>
      <tr><input type="password" v-model="password"></tr>
      <tr><td><button @click="login()">登陆</button></td>
        <td><button @click="changState()">注册</button></td>
      </tr>
    </form>
    <form v-else>
      <tr>用户名：</tr>
      <tr><input type="text" v-model="username"></tr>
      <tr>密码：</tr>
      <tr><input type="password" v-model="password"></tr>
      <tr>重复输入密码：</tr>
      <tr><input type="password" v-model="repassword"></tr>
      <tr><td><button @click="reg()">确定</button></td>
        <td><button @click="changState()">取消</button></td>
      </tr>
    </form>
  </div>
</template>

<script>
export default {
  name: 'Login',
  data () {
    return {
      username: '',
      password: '',
      repassword: '',
      isReg: false
    }
  },
  methods: {
    login () {
      if (this.username === localStorage.getItem('username') && this.password === localStorage.getItem('password')) {
        this.username = ''
        this.password = ''
        this.$router.push('/New')
      } else {
        alert('账号密码不正确！')
      }
    },
    reg () {
      if (this.password === this.repassword) {
        localStorage.setItem('username', this.username)
        localStorage.setItem('password', this.password)
        this.username = ''
        this.password = ''
        this.repassword = ''
        this.changState()
      } else {
        alert('两次密码不一致')
      }
    },
    changState () {
      this.isReg = !this.isReg
    }
  }
}
</script>

<style scoped>
  * {
    margin: 0;
    padding: 0;
  }
  form {
    margin: auto;
    text-align: center;
  }
</style>
