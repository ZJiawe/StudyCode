import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    count: 0,
    List: []
  },
  mutations: {
    increase () {
      this.state.count++
    },
    commitNews (title, content) {
      this.state.List.push(content)
    }
  },
  actions: {

  }
})
