<template>
  <div class="about">
    <h1>This is an about page</h1>
  </div>
  <div>
    <button @click="count++">
      Count is: {{ count }}
    </button>
  </div>
  <div>
    <button @click="seen = !seen">
      Change state
    </button>
    <p v-if="seen">Сейчас меня видно</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      count: 0,
      seen: true,
    };
  },
};
</script>

<style>
div + div { margin-top: 15px; } /*смежные селекторы*/
</style>
