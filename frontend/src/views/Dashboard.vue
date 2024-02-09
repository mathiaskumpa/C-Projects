<script setup>
import MovieCard from "@/components/MovieCard.vue";
import axios from "axios";
import { onMounted, ref } from "vue";

const movies = ref([]);

async function fetchMovies() {
  const response = await axios.get("https://freetestapi.com/api/v1/movies");
  movies.value = response.data;
}

onMounted(() => {
  fetchMovies();
});
</script>
<template>
  <div class="h-full flex flex-col">
    <div class="relative">
      <video class="w-screen max-h-[75vh] object-cover" autoplay loop>
        <source src="@/assets/pexels.mp4" type="video/mp4" />
        Your browser does not support the video tag.
      </video>
      <div class="absolute top-0 h-full w-full">
        <div
          class="title_wrapper absolute bottom-0 p-12 left-0 right-0 w-full bg-gradient-to-t from-gray-950 to-gray-800/0"
        >
          <span class="text-white text-xl">Trending Today</span>
          <h1 class="text-white text-6xl">
            The Untold Story of the Great Journey
          </h1>
          <button class="bg-red-600 px-6 py-4 text-white">Watch It Now</button>
        </div>
      </div>
    </div>

    <div class="mt-6 max-w-7xl mx-auto">
      <div class="grid grid-cols-3 gap-6">
        <MovieCard v-for="movie in movies" :key="movie.id" :movie="movie" />
      </div>
    </div>
  </div>
</template>
<style scoped lang="scss">
img {
  -webkit-box-reflect: below 5px
    linear-gradient(transparent, transparent, rgba(0, 0, 0, 0.4));
  -webkit-transition: all 0.5s ease;
  -o-transition: all 0.5s ease;
  transition: all 0.5s ease;
}
</style>
