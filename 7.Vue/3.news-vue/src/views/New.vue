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
      <button @click="commitNew()">提交</button>
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
    commitNew () {
      store.commit('commitNews', {
        title: this.title,
        content: this.content
      })
      this.title = ''
      this.content = ''
    }
  }
}
</script>

<style scoped>

</style>
