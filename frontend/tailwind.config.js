module.exports = {
  mode: "jit",
  content: [
    './pages/**/*.{js,ts,jsx,tsx}',
    './components/**/*.{js,ts,jsx,tsx}',
  ],
  theme: {
    fontFamily: {
      "fredoka": ["Fredoka", "sans-serif"],
      "fira-sans": ["Fira Sans", "sans-serif"]
    },
    screens: {
      "desktop": {
        min: "1001px",
      },
      "mobile": {
        max: "1000px"
      },
    },
    extend: {},
  },
  plugins: [],
}
