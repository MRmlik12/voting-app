import type { NextPage } from 'next'
import IndexContent from '../components/index/IndexContent'
import IndexLogo from '../components/index/IndexLogo'

const Home: NextPage = () => {
  return (
    <div className="container">
      <IndexLogo />
      <IndexContent />
    </div>
  )
}

export default Home
