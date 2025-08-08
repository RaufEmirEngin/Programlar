<template>
  <div>
    <h1>{{ actor.name }}</h1>
    <img :src="actor.photo" alt="Actor Photo" />
    <p>Details about {{ actor.name }}</p>
  </div>
</template>

<script>
import movies from '../data/movies.json';

export default {
  props: ['id'],
  computed: {
    actor() {
      for (let movie of movies) {
        const actor = movie.actors.find(actor => actor.id === parseInt(this.id));
        if (actor) return actor;
      }
      return {};
    }
  }
};
</script>
