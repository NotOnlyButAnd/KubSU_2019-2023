var state = {
    articles: []
  };
  
  fetch('/articles.json')
    .then(response => response.json())
    .then(articles => state.articles = articles);
  console.log('Fetch data');
  
  export default state
  