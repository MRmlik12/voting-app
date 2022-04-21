import type { NextPage } from 'next'
import IndexContent from '../components/index/IndexContent'
import IndexLogo from '../components/index/IndexLogo'

const Home: NextPage = () => {
  return (
    <div className="flex flex-col items-center">
      <IndexLogo />
      <IndexContent />
    </div>
  )
}

export default Home
