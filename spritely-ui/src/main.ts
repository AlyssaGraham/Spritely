import '@babel/polyfill'
import 'mutationobserver-shim'
import Vue from 'vue'
import './plugins/bootstrap-vue'
import App from './App.vue'
import { BootstrapVue } from 'bootstrap-vue';
import VeeValidate from 'vee-validate';

Vue.config.productionTip = false
Vue.use(BootstrapVue);
Vue.use(VeeValidate);

new Vue({
  render: h => h(App),
}).$mount('#app')
