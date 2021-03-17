<template>
  <div id="app">
    <SpritelyUi />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import SpritelyUi from './components/Spritely.vue';

@Component({
  components: {
    SpritelyUi,
  },
})
export default class App extends Vue { }
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
