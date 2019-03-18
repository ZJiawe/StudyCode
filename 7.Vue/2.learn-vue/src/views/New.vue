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
      <button @click="goNewList()">跳转列表新闻</button>
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
    },
    goNewList () {
      this.router.push('/')
    }
  }
}
</script>

<style scoped>

</style>
