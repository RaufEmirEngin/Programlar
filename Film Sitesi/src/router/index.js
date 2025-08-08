import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import MovieView from '../views/MovieView.vue';
import ActorView from '../views/ActorView.vue';

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/movie/:id', name: 'MovieView', component: MovieView, props: true },
  { path: '/actor/:id', name: 'ActorView', component: ActorView, props: true },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
