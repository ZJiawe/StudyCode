<template>
  <div>
    <p>添加新闻</p>
    <div>
      <p>Tiltle:</p>
      <input v-model="title">
      <p>content:</p>
      <input v-model="content">
    </div>
    <div>
      <button @click="add()">提交</button>
      <button @click="goNewList()">返回主页</button>
    </div>
  </div>
</template>

<script>
import store from '@/store'
export default {
  name: 'New',
  data () {
    return {
      title: '',
      content: ''
    }
  },
  methods: {
    add () {
      store.commit('commitNews', {
        title: this.title,
        content: this.content
      })
      this.title = ''
      this.content = ''
      this.$router.push('/List')
    },
    goNewList () {
      this.$router.push('/Home')
    }
  }
}
</script>

<style scoped>

</style>
