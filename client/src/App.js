import React, { Component } from 'react';
import './App.css';
import LyricsForm from './lyrics/lyricsForm'
import Header from './layout/Header';
import LyricsList from './lyrics/lyricsList';

class App extends Component {
  render() {
    return (
      <div>
        {/* <Header></Header> */}
        <div className="Mint">
          <header className="App-header">
            <h1>Lyrical OG</h1>
            {/* <LyricsList/> */}
          </header>
          <LyricsForm />
        </div>
      </div>
    );
  }
}

export default App;
