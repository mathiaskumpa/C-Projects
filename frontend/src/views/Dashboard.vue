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
      <video class="w-screen max-h-[50vh] object-cover" autoplay loop>
        <source src="@/assets/pexels.mp4" type="video/mp4" />
        Your browser does not support the video tag.
      </video>
      <div class="absolute top-0 h-full w-full">

        <div class="absolute bottom-0 w-full flex flex-col p-6 bg-gradient-to-t from-gray-950 to-gray-800/0">
          <span class="text-xl text-white">Trending Today</span>
          <span class="text-6xl text-white">The Butcher From The Dead Sea</span>
          <button class="text-white bg-red-600 px-6 py-4 w-[150px] mt-3">Watch Now</button>
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
