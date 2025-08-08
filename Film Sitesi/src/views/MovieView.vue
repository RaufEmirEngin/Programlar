<template>
  <div>
    <h1>{{ movie.title }}</h1>
    <img :src="movie.poster" alt="Movie Poster" />
    <p>{{ movie.description }}</p>
    <h3>Actors:</h3>
    <div v-for="actor in movie.actors" :key="actor.id">
      <router-link :to="`/actor/${actor.id}`">
        <img :src="actor.photo" alt="Actor Photo" />
        <p>{{ actor.name }}</p>
      </router-link>
    </div>
  </div>
</template>

<script>
import movies from '../data/movies.json';

export default {
  props: ['id'],
  computed: {
    movie() {
      return movies.find(movie => movie.id === parseInt(this.id));
    }
  }
};
</script>
