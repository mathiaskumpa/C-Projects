<script setup>
const props = defineProps({
  movie: Object,
});
</script>
<template>
  <div class="movie-card">
    <img :src="movie.poster" class="h-[320] w-[320px] object-cover" />

    <div class="flex flex-col mt-3">
      <span class="text-3xl">{{ movie.title }}</span>
      <small>Year: {{ movie.year }}</small>
      <small>Genre: {{ movie.genre }}</small>
    </div>
  </div>
</template>
<style scoped lang="scss"></style>
