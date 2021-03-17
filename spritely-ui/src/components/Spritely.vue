<template>
  <div>
    <b-jumbotron>
      <template #header>Spritely</template>

      <template #lead> Take your links and make them spritely.</template>

      <hr class="my-4" />
      <div></div>

      <div class="shorten-form">
        <b-form v-on:submit.prevent="">
          <span v-if="hasErrors">{{
            this.$validator.errors.items[0].msg
          }}</span>
          <div class="input-group mb-3">
            <b-form-input
              v-model="url"
              placeholder="Enter a url to shorten"
              v-validate="'required|url'"
              name="url"
            />
            <div class="input-group-append">
              <b-button class="submit-btn" type="submit" v-on:click="shortenUrl"
                >submit</b-button
              >
            </div>
          </div>

          <b-textarea
            class="short-link"
            id="short-link"
            v-model="shortUrl"
            readonly
          ></b-textarea>
          <div class="copy-btn-div">
            <b-button class="copy-btn" v-on:click="copy"
              >Copy to clipboard</b-button
            >
          </div>
        </b-form>
      </div>
    </b-jumbotron>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import axios from 'axios';
import * as config from '../config/config.json';


@Component({
  inject: {
    $validator: '$validator',
  }
})
export default class SpritelyUi extends Vue {
  name = 'spritely-ui';

  url = '';

  shortUrl = '';

  hasErrors = false;

  async shortenUrl() {
    this.$validator.validateAll().then(async (result) => {
      if (result) {
        this.hasErrors = false;
        await axios.get(`${config.spritelyHost}\\api\\shorten?url=${this.url}`).then((res) => this.shortUrl = res.data);
        return;
      }
      this.hasErrors = true;
    });
  }

  copy() {
    const shortLink = document.getElementById("short-link") as HTMLInputElement;
    shortLink?.focus();
    shortLink?.select();
    document.execCommand('copy');
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.shorten-form {
  width: 40vw;
}
.copy-btn-div {
  float: right;
}
.submit-btn {
  width: 10em;
}
.copy-btn {
  width: 10em;
}
.short-link {
  width: calc(40vw - 10em);
  float: left;
  height: calc(1.5em + 0.75rem + 2px);
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: #495057;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid #ced4da;
  border-radius: 0.25rem;
}
</style>
