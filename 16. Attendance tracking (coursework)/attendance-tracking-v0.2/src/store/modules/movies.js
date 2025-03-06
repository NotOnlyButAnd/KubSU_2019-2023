import IDs from "@/store/mock/OMDB_250";
import axios from "@/plugins/axios";
import mutations from "@/store/mutations";

function serializeResponse(movies) {
  return movies.reduce((acc, movie) => {
    acc[movie.imdbID] = movie;
    return acc;
  }, {});
}

const { MOVIES } = mutations;

const moviesStore = {
  namespaced: true,
  state: {
    top250IDS: IDs,
    moviesPerPage: 12,
    currentPage: 1,
    movies: {},
  },
  getters: {
    slicedIDs:
      ({ top250IDS }) =>
      (from, to) =>
        top250IDS.slice(from, to),
    moviesPerPage: ({ moviesPerPage }) => moviesPerPage,
    currentPage: ({ currentPage }) => currentPage,
  },
  mutations: {
    [MOVIES](state, value) {
      state.movies = value;
    },
  },
  actions: {
    async fetchMovies({ getters, commit }) {
      try {
        const { currentPage, moviesPerPage, slicedIDs } = getters;
        const from = currentPage * moviesPerPage - moviesPerPage;
        const to = currentPage * moviesPerPage;
        const moviesToFetch = slicedIDs(from, to);

        const requests = moviesToFetch.map((id) => axios.get(`/?i=${id}`));
        const response = await Promise.all(requests);
        // other way to send 1 request
        // const response = await axios.get("/", {
        //   params: {
        //     i: "tt0111161",
        //   },
        // });
        //console.log(response);
        const movies = serializeResponse(response);
        console.log(movies);
        commit(MOVIES, movies);
      } catch (err) {
        console.log(err);
      }
    },
  },
};

export default moviesStore;
