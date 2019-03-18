<template>
  <div>
    <div v-if="isCreate">
    <p>账号</p>
    <input v-model="account">
    <p>密码</p>
    <input v-model="password">
    <p>验证密码</p>
    <input v-model="repassword">
    </div>
    <div v-else>
      <p>这是登陆界面</p>
      <p>账号</p>
      <input v-model="account">
      <p>密码</p>
      <input v-model="password">
    </div>
    <div>
      <button @click="login()">{{state}}</button>
      <button @click="add()">提交</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Login',
  data () {
    return {
      isCreate: true,
      account: '',
      password: '',
      repassword: '',
      state: '登陆'
    }
  },
  methods: {
    login () {
      this.isCreate = !this.isCreate
      if (!this.isCreate) {
        this.state = '注册'
      } else {
        this.state = '登陆'
      }
    },
    add () {
      if (this.state === '登陆') {
        this.router.push('/User/Add')
      }
    }
  }
}
</script>

<style scoped lang="sass">

</style>
