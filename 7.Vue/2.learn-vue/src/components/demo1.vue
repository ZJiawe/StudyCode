<template xmlns:v-key="http://www.w3.org/1999/xhtml">

  <div>
    <ul>
      <li v-for="(item, index) in list"
          :key="index"
          :class="{ active: index == courrent && courrent !== '' }"
          @click="choose(index)"
      >
          {{item}}
      </li>
    </ul>
    <button @click="add()">点击添加</button>
    <ul>
      <li v-for="(item, index) in target"
          :key="index"
      >
        {{item}}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'demo1',
  data () {
    return {
      list: [8, 2, 3, 4, 5, 6, 7, 8],
      target: [],
      courrent: ''
    }
  },
  methods: {
    choose (index) {
      this.courrent = index
    },
    add () {
      if (this.courrent === '') return
      this.target.push(this.list[this.courrent])
      this.courrent = ''
    }
  }
}
</script>

<style>
  li.active{
    background: green;
    color: blueviolet;
  }
</style>
