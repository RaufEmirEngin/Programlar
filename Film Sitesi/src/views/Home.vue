<template>
  <div>
    <h1>Movie List</h1>
    <div v-for="movie in movies" :key="movie.id">
      <router-link :to="`/movie/${movie.id}`">
        <img :src="movie.poster" alt="Movie Poster" />
        <h2>{{ movie.title }}</h2>
      </router-link>
      <p>Rating: {{ movie.rating }}</p>
      <p>Reviews: {{ movie.reviews }}</p>
    </div>
  </div>
</template>

<script>
import movies from '../data/movies.json';

export default {
  data() {
    return {
      movies
    };
  }
};
</script>
