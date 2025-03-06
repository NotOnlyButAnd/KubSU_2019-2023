<template>
  <input
      type="text"
      v-bind:placeholder="placeholder"
      v-bind:value="value"
      v-on:input="$emit('input', $event.target.value)"
    >
</template>

<script>
export default {
  name: 'CustomInput',
  props: ['value', 'placeholder']
}
</script>

<style scoped>
input {
  margin: 0 0 10px 0;
  border: 2px solid gray;
  border-radius: 6px;
}
</style>
